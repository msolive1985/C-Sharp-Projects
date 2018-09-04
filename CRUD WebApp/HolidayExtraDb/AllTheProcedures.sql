CREATE PROCEDURE DeleteUser
@id int
AS
BEGIN
	Declare @referenceCount int, @returnValue int;
	SET @referenceCount = (SELECT COUNT(id) FROM AirparkUsers WHERE id=@id);
	SET @returnValue = 0;

	IF @referenceCount = 1
	BEGIN
		DELETE FROM AirparkUsers WHERE id = @id;
		SET @returnValue = 1;
	END

	SELECT @returnValue;
END

Go

CREATE PROCEDURE getAllUsers
AS
SELECT id, email, givenName, familyName, created 
FROM AirparkUsers 
ORDER BY familyName;

Go

CREATE PROCEDURE InsertLog
@dtError DATETIME,
@vcError VARCHAR(MAX),
@vcErrorStack VARCHAR(MAX)

AS

INSERT INTO tblErrorLog
SELECT @dtError, @vcError, @vcErrorStack;

Go

CREATE PROCEDURE InsertNewUser
@email VARCHAR(MAX),
@givenName VARCHAR(MAX),
@familyName VARCHAR(MAX)

AS
BEGIN
	Declare @referenceCount int, @returnValue int;
	SET @referenceCount = (SELECT COUNT(id) FROM AirparkUsers WHERE email = @email AND givenName = @givenName AND familyName = @familyName);
	SET @returnValue = 0;

	IF @referenceCount = 0
	BEGIN
		INSERT INTO AirparkUsers
			SELECT @email, @givenName, @familyName, GETDATE();
		SET @returnValue = 1;
	END

	SELECT @returnValue;
END

Go

CREATE PROCEDURE SelectUserByID
@id INT

AS

BEGIN
	SELECT id, email, givenName, familyName, created 
	FROM AirparkUsers
	WHERE id = @id;
END

Go

CREATE PROCEDURE UpdateUserInfo
@id INT,
@email VARCHAR(MAX),
@givenName VARCHAR(MAX),
@familyName VARCHAR(MAX)

AS

BEGIN
	UPDATE AirparkUsers
	SET email = @email, 
		givenName = @givenName, 
		familyName = @familyName, 
		created = GETDATE()
	WHERE id = @id;
END


Go
