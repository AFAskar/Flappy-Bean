#!/bin/bash
# Helper script to run WebGL build locally
# Usage: ./run_webgl.sh [path_to_build_folder]

BUILD_PATH="${1:-WebGL}"

if [ ! -d "$BUILD_PATH" ]; then
    echo "Error: Build directory '$BUILD_PATH' not found."
    echo "Usage: ./run_webgl.sh [path_to_build_folder]"
    echo "Default path is 'WebGL'"
    exit 1
fi

echo "Starting local web server for WebGL build at '$BUILD_PATH'..."
echo "Open http://localhost:8000 in your browser."
echo "Press Ctrl+C to stop."

SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"

python3 "$SCRIPT_DIR/serve.py" "$BUILD_PATH"
