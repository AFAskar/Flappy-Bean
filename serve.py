import http.server
import socketserver
import sys
import os

PORT = 8000
DIRECTORY = sys.argv[1] if len(sys.argv) > 1 else "."

import urllib.parse

class Handler(http.server.SimpleHTTPRequestHandler):
    def do_GET(self):
        # Force a fresh response by removing conditional headers
        # This prevents 304 Not Modified responses which would use the browser's cached headers (missing Content-Encoding)
        if 'If-Modified-Since' in self.headers:
            del self.headers['If-Modified-Since']
        if 'If-None-Match' in self.headers:
            del self.headers['If-None-Match']
        super().do_GET()

    def end_headers(self):
        # Parse path to ignore query parameters
        parsed_path = urllib.parse.urlparse(self.path).path
        
        # Add Content-Encoding for compressed files
        if parsed_path.endswith('.br'):
            self.send_header('Content-Encoding', 'br')
        elif parsed_path.endswith('.gz'):
            self.send_header('Content-Encoding', 'gzip')
            
        # Disable caching
        self.send_header('Cache-Control', 'no-store, no-cache, must-revalidate, max-age=0')
        self.send_header('Pragma', 'no-cache')
        self.send_header('Expires', '0')
        
        super().end_headers()

    def guess_type(self, path):
        # Detect MIME type based on the file extension (ignoring .br/.gz)
        base, ext = os.path.splitext(path)
        if ext in ('.br', '.gz'):
            return super().guess_type(base)
        return super().guess_type(path)

if __name__ == "__main__":
    if not os.path.isdir(DIRECTORY):
        print(f"Error: Directory '{DIRECTORY}' not found.")
        sys.exit(1)
        
    os.chdir(DIRECTORY)
    print(f"Serving '{DIRECTORY}' on http://localhost:{PORT}")
    
    # Allow address reuse to avoid "Address already in use" errors on restart
    socketserver.TCPServer.allow_reuse_address = True
    
    with socketserver.TCPServer(("", PORT), Handler) as httpd:
        try:
            httpd.serve_forever()
        except KeyboardInterrupt:
            print("\nServer stopped.")
