function Login() {
	this.ctrlActions;
	this.service = 'Login';
	this.tblJobsId = 'tblJobs';
	this.columns = "Fullname,DateTime,Email";

	this.Iniciar = function () {
		this.ctrlActions = new ControlActions();
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.PostAPI2(this.service, customerData, (response) => {
			if (response == "Bienvido a SafeJob.") {
				window.location.href = 'https://localhost:44338/Home/listado';
			} else {
				this.ctrlActions.ShowMessage('E', response);
			}
		}, (error) => {
			console.log(error);
			this.ctrlActions.ShowMessage('E', error);
		});
	}
}

$(document).ready(function () {
	console.log("holis");
	/*var registroCancha = new RegistroCancha();
	registroCancha.RetrieveAll();
	registroCancha.SelectedRow();*/
});