#!/bin/bash
# Helper script to run WebGL build locally
# Usage: ./run_webgl.sh [path_to_build_folder]

BUILD_PATH="${1:-build/WebGL}"

if [ ! -d "$BUILD_PATH" ]; then
    echo "Error: Build directory '$BUILD_PATH' not found."
    echo "Usage: ./run_webgl.sh [path_to_build_folder]"
    echo "Default path is 'build/WebGL'"
    exit 1
fi

echo "Starting local web server for WebGL build at '$BUILD_PATH'..."
echo "Open http://localhost:8000 in your browser."
echo "Press Ctrl+C to stop."

cd "$BUILD_PATH"
python3 -m http.server 8000
