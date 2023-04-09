import os

os.system("docker exec -it product-service /app/migrations-bundle")

input("Press any key to exit...")
