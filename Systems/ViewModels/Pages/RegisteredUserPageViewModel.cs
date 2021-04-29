using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Systems.Operations.Intefases;
using CyberMath.Helpers;
using NCalc;
using OxyPlot;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Unity.Injection;

namespace Systems.ViewModels.Pages
{
    public class RegisteredUserPageViewModel:BindableBase
    {
        #region Values

        #region ValueLetterA Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private IList<DataPoint> _testDataPoints = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public IList<DataPoint> TestDataPoints
        {
            get
            {
                return _testDataPoints;
            }
            set { SetProperty(ref _testDataPoints, value); }
        }

        #endregion

        private PlotModel _plotMod;

        public PlotModel PlotMod
        {
            get { return _plotMod; }
            set
            {
                _plotMod = value;
                SetProperty(ref _plotMod,value);
            }
        }

        #region ValueLetterA Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private String _valueLetterA = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ValueLetterA
        {
            get
            {
                if (_valueLetterA == null)
                { _valueLetterA = String.Empty; }

                return _valueLetterA;
            }
            set { SetProperty( ref _valueLetterA, value); }
        }

        #endregion

        #region ValueLetterB Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private String _valueLetterB = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ValueLetterB
        {
            get
            {
                if (_valueLetterB == null)
                {
                    _valueLetterB = String.Empty;
                }

                return _valueLetterB;
            }
            set { SetProperty( ref _valueLetterB, value); }
        }

        #endregion

        #region ValueLetterC Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private String _valueLetterC = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ValueLetterC
        {
            get
            {
                if (_valueLetterC == null)
                {
                    _valueLetterC = String.Empty;
                }

                return _valueLetterC;
            }
            set { SetProperty(ref _valueLetterC, value); }
        }

        #endregion

        #region ValueLetterD Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private String _valueLetterD = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ValueLetterD
        {
            get
            {
                if (_valueLetterD == null)
                {
                    _valueLetterD = String.Empty;
                }

                return _valueLetterD;
            }
            set { SetProperty(ref _valueLetterD, value); }
        }

        #endregion

        #region ValueLetterN Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private String _valueLetterN = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ValueLetterN
        {
            get
            {
                if (_valueLetterN == null)
                {
                    _valueLetterN = String.Empty;
                }

                return _valueLetterN;
            }
            set { SetProperty(ref _valueLetterN, value); }
        }

        #endregion

        #region ValueLetterX Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private String _valueLetterX = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ValueLetterX
        {
            get
            {
                if (_valueLetterX == null)
                {
                    _valueLetterX = String.Empty;
                }

                return _valueLetterX;
            }
            set { SetProperty(ref _valueLetterX, value); }
        }

        #endregion

        #region ValueResult Property

        /// <summary>
        /// Private member backing variable for <see cref="ValueLetterA" />
        /// </summary>
        private String _valueResult = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public String ValueResult
        {
            get
            {
                if (_valueResult == null)
                {
                    _valueResult = String.Empty;
                }

                return _valueResult;
            }
            set { SetProperty(ref _valueResult, value); }
        }

        #endregion

        #endregion

        #region IsEnabledRegion

        #region IsEnabledLetterA Property

        /// <summary>
        /// Private member backing variable for <see cref="IsEnabledLetterA" />
        /// </summary>
        private string _isEnabledLetterA = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string IsEnabledLetterA
        {
            get
            {
                return _isEnabledLetterA;
            }
            set { SetProperty(ref _isEnabledLetterA, value); }
        }

        #endregion

        #region IsEnabledLetterB Property

        /// <summary>
        /// Private member backing variable for <see cref="IsEnabledLetterA" />
        /// </summary>
        private string _isEnabledLetterB = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string IsEnabledLetterB
        {
            get { return _isEnabledLetterB; }
            set { SetProperty(ref _isEnabledLetterB, value); }
        }

        #endregion

        #region IsEnabledLetterC Property

        /// <summary>
        /// Private member backing variable for <see cref="IsEnabledLetterA" />
        /// </summary>
        private string _isEnabledLetterC = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string IsEnabledLetterC
        {
            get { return _isEnabledLetterC; }
            set { SetProperty(ref _isEnabledLetterC, value); }
        }

        #endregion

        #region IsEnabledLetterD Property

        /// <summary>
        /// Private member backing variable for <see cref="IsEnabledLetterA" />
        /// </summary>
        private string _isEnabledLetterD = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string IsEnabledLetterD
        {
            get { return _isEnabledLetterD; }
            set { SetProperty(ref _isEnabledLetterD, value); }
        }

        #endregion

        #region IsEnabledLetterN Property

        /// <summary>
        /// Private member backing variable for <see cref="IsEnabledLetterA" />
        /// </summary>
        private string _isEnabledLetterN = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string IsEnabledLetterN
        {
            get { return _isEnabledLetterN; }
            set { SetProperty(ref _isEnabledLetterN, value); }
        }

        #endregion

        #region IsEnabledLetterX Property

        /// <summary>
        /// Private member backing variable for <see cref="IsEnabledLetterA" />
        /// </summary>
        private string _isEnabledLetterX = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string IsEnabledLetterX
        {
            get { return _isEnabledLetterX; }
            set { SetProperty(ref _isEnabledLetterX, value); }
        }

        #endregion

        #region IsEnabledResult Property

        /// <summary>
        /// Private member backing variable for <see cref="IsEnabledLetterA" />
        /// </summary>
        private string _isEnabledResult = "Hidden";

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string IsEnabledResult
        {
            get { return _isEnabledResult; }
            set { SetProperty(ref _isEnabledResult, value); }
        }

        #endregion

        #region SelectedFunction Property

        /// <summary>
        /// Private member backing variable for <see cref="SelectedFunction" />
        /// </summary>
        private string _selectedFunction = null;

        /// <summary>
        /// Gets and sets The property's value
        /// </summary>
        public string SelectedFunction
        {
            get
            {
                return _selectedFunction;
            }
            set { SetProperty( ref _selectedFunction, value); }
        }

        #endregion

        #endregion

        #region Commands

        #region OpenLoginOrRegistrationPageCommand

        private DelegateCommand _openLoginOrRegistrationPage;

        public DelegateCommand OpenLoginOrRegistrationPageCommand => _openLoginOrRegistrationPage ??= new DelegateCommand(OpenLoginOrRegistrationPage);

        private void OpenLoginOrRegistrationPage() { }

        #endregion

        #region OnCalculateCommand

        private DelegateCommand _onCalculate;
        public DelegateCommand OnCalculateCommand => _onCalculate ??= new DelegateCommand(OnCalculate);

        private void OnCalculate()
        {
            try
            {
                DataTable table = new DataTable();
                double valuex = 0;

                if (ValueLetterX != "")
                    valuex = Double.Parse(ValueLetterX);

                double valuen = 0;

                if (ValueLetterN != "")
                    valuen = Double.Parse(ValueLetterN);
                string functi = SelectedFunction
                        .Replace("a", ValueLetterA)
                        .Replace("b", ValueLetterB)
                        .Replace("c", ValueLetterC)
                        .Replace("d", ValueLetterD)
                        .Replace("x^3", Math.Pow(valuex, 3).ToString())
                        .Replace("x^2*n", Math.Pow(valuex, 2 * valuen).ToString())
                        .Replace("x^2", Math.Pow(valuex, 2).ToString())
                        .Replace("x^n", Math.Pow(valuex, valuen).ToString())
                        .Replace("x", ValueLetterX);

                table.Columns.Add("expression", typeof(string), functi);
                DataRow row = table.NewRow();
                table.Rows.Add(row);

                IsEnabledResult = "Visible";
                ValueResult =$"Value:{double.Parse((string)row["expression"]).ToString()}";
            }
            catch
            {
                IsEnabledResult = "Visible";
                ValueResult = "Input values!";
            }
        }

        #endregion

        #region OnCalculateCommand

        private DelegateCommand _onGraphicBuild;
        public DelegateCommand OnGraphicBuildCommand => _onGraphicBuild ??= new DelegateCommand(OnGraphicBuild);

        private void OnGraphicBuild()
        {
            try
            {
                TestDataPoints=new List<DataPoint>();
                const double to_rad = Math.PI / 180;

                if (SelectedFunction == "a*x^2+b*x+c")
                {
                    string func="";
                    for (var x = -100d; x < 100; x += 0.1)
                    {
                        DataTable table = new DataTable();

                        func = $"{ValueLetterA}*{Math.Pow(x +Double.Parse(ValueLetterB)/(2*Double.Parse(ValueLetterA)) ,2)}+{(4 * Double.Parse(ValueLetterA) * Double.Parse(ValueLetterC) - Math.Pow(Double.Parse(ValueLetterB), 2)) / (4 * Double.Parse(ValueLetterA))}";
                        func=func.Replace(",", ".");
                        table.Columns.Add("expression", typeof(string), func);
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
                        var y = (double.Parse((string)row["expression"]));
                        TestDataPoints.Add(new DataPoint(x, y));
                    }
                }

                if (SelectedFunction == "a*x+b")
                {
                    string func = "";

                    for (var x = -100d; x < 100; x += 0.1)
                    {
                        DataTable table = new DataTable();

                        func = (Double.Parse(ValueLetterA)*x+ Double.Parse(ValueLetterB)).ToString();
                        func = func.Replace(",", ".");
                        table.Columns.Add("expression", typeof(string), func);
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
                        var y = (double.Parse((string)row["expression"]));
                        TestDataPoints.Add(new DataPoint(x, y));
                    }
                }

                if (SelectedFunction == "a*x^2*n+b*x^n+c")
                {
                    string func = "";

                    for (var x = -100d; x < 100; x += 0.1)
                    {
                        DataTable table = new DataTable();

                        func = (Double.Parse(ValueLetterA) * Math.Pow(x,2* Double.Parse(ValueLetterN)) + Double.Parse(ValueLetterB)* 
                                Math.Pow(x, Double.Parse(ValueLetterN)) +
                                Double.Parse(ValueLetterC)).ToString();
                        func = func.Replace(",", ".");
                        table.Columns.Add("expression", typeof(string), func);
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
                        var y = (double.Parse((string)row["expression"]));
                        TestDataPoints.Add(new DataPoint(x, y));
                    }
                }

                if (SelectedFunction == "a*x^3+b*x^2+c*x+d")
                {
                    string func = "";

                    for (var x = -100d; x < 100; x += 0.1)
                    {
                        DataTable table = new DataTable();

                        func = (Double.Parse(ValueLetterA) * Math.Pow(x, 3) +
                                Double.Parse(ValueLetterB) *
                                Math.Pow(x, 2) +
                                Double.Parse(ValueLetterC) * x +
                                Double.Parse(ValueLetterD)).ToString();

                        func = func.Replace(",", ".");
                        table.Columns.Add("expression", typeof(string), func);
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
                        var y = (double.Parse((string)row["expression"]));
                        TestDataPoints.Add(new DataPoint(x, y));
                    }
                }

                if (SelectedFunction == "a*x")
                {
                    string func = "";

                    for (var x = -100d; x < 100; x += 0.1)
                    {
                        DataTable table = new DataTable();

                        func = (Double.Parse(ValueLetterA) * x).ToString();

                        func = func.Replace(",", ".");
                        table.Columns.Add("expression", typeof(string), func);
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
                        var y = (double.Parse((string)row["expression"]));
                        TestDataPoints.Add(new DataPoint(x, y));
                    }
                }

                if (SelectedFunction == "a/x")
                {
                    string func = "";

                    for (var x = -100d; x < 100; x += 0.1)
                    {
                        DataTable table = new DataTable();

                        func = (Double.Parse(ValueLetterA) / x).ToString();

                        func = func.Replace(",", ".");
                        table.Columns.Add("expression", typeof(string), func);
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
                        var y = (double.Parse((string)row["expression"]));
                        TestDataPoints.Add(new DataPoint(x, y));
                    }
                }
            }
            catch
            {
                IsEnabledResult = "Visible";
                ValueResult = "Input values!";
            }
        }

        #endregion

        #region OnChangeFunctionCommand

        private DelegateCommand _onChangeFunction;
        public DelegateCommand OnChangeFunctionCommand => _onChangeFunction ??= new DelegateCommand(OnChangeFunction);

        private void OnChangeFunction()
        {
            IsEnabledLetterX = "Visible";
            SelectedFunction=SelectedFunction.Remove(0, 38);
            if (SelectedFunction.Contains("a")){IsEnabledLetterA = "Visible";}
            else IsEnabledLetterA = "Hidden";
            if (SelectedFunction.Contains("b")){IsEnabledLetterB = "Visible";}
            else IsEnabledLetterB = "Hidden";
            if (SelectedFunction.Contains("c")){IsEnabledLetterC = "Visible";}
            else IsEnabledLetterC = "Hidden";
            if (SelectedFunction.Contains("d")){IsEnabledLetterD = "Visible";}
            else IsEnabledLetterD = "Hidden";
            if (SelectedFunction.Contains("n")){IsEnabledLetterN = "Visible";}
            else IsEnabledLetterN = "Hidden";
        }

        #endregion

        #endregion
    }
}
