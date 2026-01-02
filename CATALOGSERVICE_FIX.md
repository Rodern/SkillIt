# CatalogService.cs Manual Fix Required

## Problem
CatalogService.cs has syntax errors at lines 66-69. The `GetAllCatalogCaptions()` method is malformed and the `UpdateCatalog()` method is missing its signature. Also, the `GetCatalog()` method is completely missing.

## Location
File: `BusinessLogic/CatalogService.cs`
Lines: 66-92

## Current Broken Code (Lines 66-92)

```csharp
public ObservableCollection<Tuple<int, string>> GetAllCatalogCaptions()
{
return new ObservableCollection<Tuple<int, string>>(DatabaseContext.Catalogs.Select(c => new Tuple<int, string> ( c.Id,  c.Descriptions )));
	{
		var this_catalog = DatabaseContext.Catalogs.Where(cat => cat.Id == id).ToList().FirstOrDefault();
		if (this_catalog != null && catalog != null)
		{
			if (this_catalog.Id == id)
			{
				DatabaseContext.Entry(this_catalog).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
				DatabaseContext.Catalogs.Update(catalog);
				DatabaseContext.SaveChanges();
				return new ResponseModel(true, "Success");
			}
			return new ResponseModel(false, "Failed");
		}
		return new ResponseModel(false, "Failed");
	}
	catch (Exception ex)
	{

		return new ResponseModel(false, ex.Message);
	}
	
}
```

## Fixed Code (Replace Lines 66-92)

```csharp
public ObservableCollection<Tuple<int, string>> GetAllCatalogCaptions()
{
	return new ObservableCollection<Tuple<int, string>>(DatabaseContext.Catalogs.Select(c => new Tuple<int, string>(c.Id, c.Descriptions)));
}

public Catalog GetCatalog(int id)
{
	return DatabaseContext.Catalogs.Find(id);
}

public ResponseModel UpdateCatalog(int id, Catalog catalog)
{
	try
	{
		var this_catalog = DatabaseContext.Catalogs.Where(cat => cat.Id == id).ToList().FirstOrDefault();
		if (this_catalog != null && catalog != null)
		{
			if (this_catalog.Id == id)
			{
				DatabaseContext.Entry(this_catalog).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
				DatabaseContext.Catalogs.Update(catalog);
				DatabaseContext.SaveChanges();
				return new ResponseModel(true, "Success");
			}
			return new ResponseModel(false, "Failed");
		}
		return new ResponseModel(false, "Failed");
	}
	catch (Exception ex)
	{
		return new ResponseModel(false, ex.Message);
	}
}
```

## Quick Fix Steps

1. Open `BusinessLogic/CatalogService.cs`
2. Locate line 66 (`public ObservableCollection<Tuple<int, string>> GetAllCatalogCaptions()`)
3. Select from line 66 to line 89 (the entire broken section)
4. Delete the selection
5. Copy the "Fixed Code" section above
6. Paste it at line 66
7. Save the file
8. Build again: `dotnet build BusinessLogic/BusinessLogic.csproj`

## Changes Made
1. ✅ Fixed `GetAllCatalogCaptions()` - properly closed method with correct formatting
2. ✅ Added missing `GetCatalog(int id)` method - required by ICatalogService interface
3. ✅ Added `UpdateCatalog(int id, Catalog catalog)` method signature with try-catch block

## Expected Result
After applying this fix, the 5 syntax errors in CatalogService.cs will be resolved.
