 INSERT INTO [dbo].[Entry] (EntryID, [Name], Phonenumber)
 VALUES                    (NEWID(), @Name, @Phonenumber)