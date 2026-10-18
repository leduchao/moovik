# Cinema Booking Website (Moovik - a Moveek's parody)

#### 1. Sacffold DB:
```bash
dotnet ef dbcontext scaffold "Name=ConnectionStrings:Default" \
    Pomelo.EntityFrameworkCore.MySql \
    --output-dir Persistence/DatabaseModels \
    --context-dir Persistence \
    --context AppDbContext \
    --project ../Moovik.Infrastructure \
    --startup-project . --force
```
