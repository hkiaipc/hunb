@rem
@rem ����hunbeidb���ݿ�ű�
@rem
@echo ====================
@echo ����hunbeidb���ݿ�ű�
@echo ====================
@echo Press any key to continue, Ctrl+C to break...
@pause > nul

"C:\Program Files\Microsoft SQL Server\MSSQL\Upgrade\scptxfr.exe" /s (local) /d hunbeiguanqudbv2 /P sa /f .\hunbeiguanqudbv2.sql /q /r /A /E
