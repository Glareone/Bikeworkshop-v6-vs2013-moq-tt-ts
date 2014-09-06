CREATE TABLE [Sparepart]
(
	SparepartID			int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	SparepartName		nvarchar(100) NOT NULL,
	PartNumber			nvarchar(50) NOT NULL,
	Prise				money NOT NULL,
)
