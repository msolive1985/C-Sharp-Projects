CREATE TABLE [dbo].[tblErrorLog] (
  [dt_error] DATETIME NULL,
  [vc_error] VARCHAR(MAX),
  [vc_error_stack] VARCHAR(MAX) NULL
);