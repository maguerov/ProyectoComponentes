function RegistroCancha() {
	this.ctrlActions;
	this.service = 'Registro';
	this.tblJobsId = 'tblJobs';
	this.columns = "Fullname,DateTime,Email";

	this.RetrieveAll = function () {
		this.ctrlActions = new ControlActions();
		this.ctrlActions.FillTable(this.service, this.tblJobsId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions = new ControlActions();
		console.log("ReloadTable");
		this.ctrlActions.FillTable(this.service, this.tblJobsId, true);
	}

	this.BindFields = function (data) {
		sessionStorage.setItem("fechaT", data.DateTime);
		sessionStorage.setItem("nombreT", data.Email);
		this.ctrlActions = new ControlActions();
		this.ctrlActions.BindFields('frmEdition', data);
	}

	this.SelectedRow = function () {
		this.ctrlActions = new ControlActions();
		console.log(this.tblJobsId);
		this.ctrlActions.SelectedRowStyle(this.tblJobsId);
	}

	this.Registro = function () {
		this.ctrlActions = new ControlActions();
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.PostToAPI(this.service, customerData);
		//window.location.href = 'https://localhost:44338/Home/Registro';
	}
	this.Actualizar = function () {
		this.ctrlActions = new ControlActions();
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		var nombreOriginal = customerData.Email;
		customerData.DateTime = sessionStorage.getItem("fechaT");
		customerData.Email = sessionStorage.getItem("fechaT");
		var nombreFin = customerData.Fullname + "," + nombreOriginal;
		console.log(sessionStorage.getItem("fechaT"));
		customerData.FullName = nombreFin;
		this.ctrlActions.PutToAPILOGIN(this.service, customerData, (response) => {
			window.location.href = 'https://localhost:44338/Home/listado';
		}, (error) => {
			console.log(error);
			this.ctrlActions.ShowMessage('E', error);
		});
	}

	this.Eliminar = function () {
		this.ctrlActions = new ControlActions();
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		customerData.Email = sessionStorage.getItem("fechaT");
		console.log("hoollaaaa");
		this.ctrlActions.DeleteToAPILOGIN(this.service, customerData, (response) => {
			window.location.href = 'https://localhost:44338/Home/listado';
		}, (error) => {
			console.log(error);
			this.ctrlActions.ShowMessage('E', error);
		});
	}

	this.Login = function () {
		window.location.href = 'https://localhost:44338/Home/Index';
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var registroCancha = new RegistroCancha();
	registroCancha.RetrieveAll();
	registroCancha.SelectedRow();
});