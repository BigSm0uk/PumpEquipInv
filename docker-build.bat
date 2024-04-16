docker build -t pump-backend -f PumpEquipInv.Api/Dockerfile .
docker run -it --rm -p 8000:5000 -e ASPNETCORE_URLS="http://*:5000" -e ASPNETCORE_ENVIRONMENT=Development pump-backend