find . -type f -iname "*.wav" -exec bash -c '
  for f; do
    ffmpeg -i "$f" -c:a flac -compression_level 12 "${f%.wav}.flac"
  done
' bash {} +
