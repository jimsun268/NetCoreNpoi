using InfrastructureLibary.ETW;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNpoiClass
{
    public class NpoiService : INpoiService
    {
        public NpoiService (IETWService eTWService, IDialogService dialogService)
        {
            _eTWService = eTWService;
            _dialogService = dialogService;
            _eTWService.ProcessingStart("ModelNpoiClass.NpoiService");
        }

        #region Fields
        private IETWService _eTWService;
        private IDialogService _dialogService;

              
        private FileInfo _fileInfo;              
        private IWorkbook _workBook;
        private List<string> _sheets;

        private static DataSet _dataSet;
        #endregion

        #region Properties
        public DataSet DataSet => _dataSet ??= new DataSet();
        public string FileExt
        {
            get
            {
                if (_fileInfo == null) GetFile();
                return _fileInfo.Extension;
            }
        }
        public string FileName
        {
            get
            {
                if (_fileInfo == null) GetFile();
                return _fileInfo.Name;
            }
        }
        public string FilePath
        {
            get
            {
                if (_fileInfo == null) GetFile();
                return _fileInfo.DirectoryName;
            }
        }

        public string[] Sheets
        {
            get
            {
                if (_workBook == null) return null;
                if (_sheets == null) GetSheets();
                return _sheets.ToArray();
            }
        }
      
        #endregion

        #region private Methods
        private void GetFile()
        {

            OpenFileDialog _openFile = new OpenFileDialog();                
            _openFile.Filter = "XLS (*.xls)|*.xls|XLSX (*.xlsx)|*.xlsx";
           
            if (_openFile.ShowDialog() == true)
            {
                _fileInfo = new FileInfo(_openFile.FileName);
               if (_fileInfo.Extension== ".xls" || _fileInfo.Extension == ".xlsx")
                {
                    try
                    {
                        _workBook = WorkbookFactory.Create(_fileInfo.OpenRead());
                        Recover();
                        _dialogService.ShowDialog("SuccessDialog", new DialogParameters($"message= {"成功打开"}{this.FileName}"), null);
                    }
                    catch (Exception ex)
                    {
                        _dialogService.ShowDialog("WarningDialog", new DialogParameters($"message={"打开文件错误！"}{ex.Message}"), null);
                    }                   
                }
                else
                {
                    _dialogService.ShowDialog("WarningDialog", new DialogParameters($"message={"请选择EXCEL文件"}"), null);
                }
            }

        }

        private void GetSheets()
        {
            if(_workBook !=null)
            {
                _sheets = new List<string>();
                for (int i = 0; i < _workBook.NumberOfSheets; i++)
                {
                    _sheets.Add(_workBook.GetSheetAt(i).SheetName);
                }
            }            
        }

        private void Recover()
        {
            _sheets = null;
        }
        #endregion

        #region Interface
        public void ShowDialog()
        {
            GetFile();
        }

        #endregion
    }
}
