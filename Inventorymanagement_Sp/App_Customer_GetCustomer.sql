-- =============================================  
-- Author:  <Khageshor Giri>  
-- Create date: <2023/05/14>  
-- Description: <Procuder to get all supplier details a Employee>  
-- =============================================  
CREATE PROCEDURE App_Customer_GetCustomer @CustomerId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from  
	-- interfering with SELECT statements.  
	SET NOCOUNT ON;

	BEGIN TRY
		SELECT C.CustomerID
			,C.CustomerName
			,C.PhoneNumber
			,C.Email
			,C.PanNumber
			,C.OtherDetails
			,AD.AddressId
			,AD.Country
			,AD.City
			,AD.LocalAddress
		FROM dbo.Customers C
		INNER JOIN DBO.Addresses AD ON AD.AddressId = C.AddressId
		WHERE C.CustomerID = @CustomerId
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
