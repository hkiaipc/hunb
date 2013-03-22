@rem
@rem 生成hunbeidb数据库脚本
@rem
@echo ====================
@echo 生成hunbeidb数据库脚本
@echo ====================
@echo Press any key to continue, Ctrl+C to break...
@pause > nul

"C:\Program Files\Microsoft SQL Server\MSSQL\Upgrade\scptxfr.exe" /s (local) /d hunbeiguanqudbv2 /P sa /f .\hunbeiguanqudbv2.sql /q /r /A /E
