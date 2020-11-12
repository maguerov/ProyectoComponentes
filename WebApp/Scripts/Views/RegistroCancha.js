function RegistroCancha() {
	this.ctrlActions;
	this.service = 'Registro';
	this.Registro = function () {
		this.ctrlActions = new ControlActions();
		var customerData = {};
		//customerData = this.ctrlActions.GetDataForm('frmEdition');
		customerData.name = "Paola Mora";
		customerData.phone = 89696205;
		this.ctrlActions.PostToAPI(this.service, customerData);
		console.log(customerData);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	console.log("hola");
});