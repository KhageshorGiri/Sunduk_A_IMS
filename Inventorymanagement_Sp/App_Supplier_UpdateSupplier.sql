
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- [Add]_[Object]_[Action/Process]
IF OBJECT_ID('App_Supplier_UpdateSupplier', 'P') IS NULL
BEGIN
	EXEC ('CREATE PROC App_Supplier_UpdateSupplier as select ''x''');
END;
GO
-- =============================================
-- Author:		<Khageshor Giri>
-- Create date: <2022/12/27>
-- Description:	<Procuder to ADD a SUPPLIER>
-- =============================================
ALTER PROCEDURE App_Supplier_UpdateSupplier
				@SupplierId INT,
				@SupplierName NVARCHAR(200),
				@Email NVARCHAR(30),
				@PhoneNumber NVARCHAR(15),
				@PanNumber NVARCHAR(15),
				@Country NVARCHAR(50),
				@City NVARCHAR(70),
				@LocalAddress NVARCHAR(150)		 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN TRANSACTION;
		-- insert to address to the addresses table
		--UPDATE SUPPLIER DETAILS

		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION;

		DECLARE @ErrorNumber INT
			,@ErrorMessage NVARCHAR(MAX)
			,@ErrorProcedure NVARCHAR(100)
			,@ErrorState INT
			,@ErrorSeverity INT
			,@ErrorLine INT;

		SELECT @ErrorNumber = ERROR_NUMBER()
			,@ErrorMessage = ERROR_MESSAGE()
			,@ErrorProcedure = ERROR_PROCEDURE()
			,@ErrorState = ERROR_STATE()
			,@ErrorSeverity = ERROR_SEVERITY()
			,@ErrorLine = ERROR_LINE();

		SELECT ERROR_NUMBER() AS [Number]
			,ERROR_MESSAGE() AS [Message]
			,ERROR_PROCEDURE() AS [ProcedureName]
			,ERROR_STATE() AS [State]
			,ERROR_SEVERITY() AS [Severity]
			,ERROR_LINE() AS [Line];

		EXEC SPErrorLog @ErrorNumber
			,@ErrorMessage
			,@ErrorProcedure
			,@ErrorState
			,@ErrorSeverity
			,@ErrorLine;

		RAISERROR (
				@ErrorMessage
				,@ErrorSeverity
				,@ErrorState
				);
	END CATCH;
END;
GO


