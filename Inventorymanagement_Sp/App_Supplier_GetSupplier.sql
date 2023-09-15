SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('App_Supplier_GetSupplier', 'P') IS NULL
BEGIN
	EXEC ('CREATE PROC App_Supplier_GetSupplier as select ''x''');
END;
GO

-- =============================================
-- Author:		<Khageshor Giri>
-- Create date: <2022/12/27>
-- Description:	<Procuder to get all supplier details by id>
-- =============================================
ALTER PROCEDURE App_Supplier_GetSupplier
				@SupplierId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY
		SELECT S.SupplierID
			,S.SupplierName
			,S.PhoneNumber
			,S.Email
			,S.PanNumber
			,S.OtherDetails
			,AD.Country
			,AD.City
			,AD.LocalAddress
		FROM dbo.Suppliers S
		INNER JOIN DBO.Addresses AD ON AD.AddressId = S.AddressId
		WHERE S.SupplierID = @SupplierId
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


