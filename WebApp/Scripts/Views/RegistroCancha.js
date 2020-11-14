function RegistroCancha() {
	this.ctrlActions;
	this.service = 'Registro';
	this.tblJobsId = 'tblJobs';
	this.columns = "Fullname,DateTime,Email";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblJobsId, false);
	}

	this.ReloadTable = function () {
		console.log("ReloadTable");
		this.ctrlActions.FillTable(this.service, this.tblJobsId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}

	this.SelectedRow = function () {
		this.ctrlActions.SelectedRowStyle(this.tblJobsId);
	}

	this.Registro = function () {
		this.ctrlActions = new ControlActions();
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//customerData.name = "Paola Mora";
		//customerData.phone = 89696205;
		this.ctrlActions.PostToAPI(this.service, customerData);
		var e = document.getElementById("fecha").value;
		console.log(e);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var registroCancha = new RegistroCancha();
	registroCancha.RetrieveAll();
	registroCancha.SelectedRow();
});