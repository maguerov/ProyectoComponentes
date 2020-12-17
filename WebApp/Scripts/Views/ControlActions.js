function ControlActions() {

	this.URL_API = "https://localhost:44323/api/";

	this.GetUrlApiService = function (service) {
		return this.URL_API + service;
	}

	this.GetUrlApiService = function (service) {
		return this.URL_API + service;
	}

	this.GetTableColumsDataName = function (tableId) {
		var val = $('#' + tableId).attr("ColumnsDataName");

		return val;
	}
	this.FillTable = function (service, tableId, refresh) {
		if (!refresh) {
			columns = this.GetTableColumsDataName(tableId).split(',');
			var arrayColumnsData = [];

			$.each(columns, function getRoutesByCompany(index, value) {
				var obj = {};
				obj.data = value;
				arrayColumnsData.push(obj);
			});

			$('#' + tableId).DataTable({
				"processing": true,
				"ajax": {
					"url": this.GetUrlApiService(service),
					dataSrc: 'Data'
				},
				"columns": arrayColumnsData
			});
		} else {
			//RECARGA LA TABLA
			$('#' + tableId).DataTable().ajax.reload();
		}

	}

	this.GetSelectedRow = function () {
		var data = sessionStorage.getItem(tableId + '_selected');
		return data;
	};

	this.SelectedRowStyle = function (tableId) {
		var table = $('#' + tableId).DataTable();

		$('#' + tableId + ' tbody').on('click', 'tr', function () {
			if ($(this).hasClass('selected')) {
				$(this).removeClass('selected');
			}
			else {
				table.$('tr.selected').removeClass('selected');
				$(this).addClass('selected');
			}
		});
	};

	this.BindFields = function (formId, data) {
		console.log(data);
		$('#' + formId + ' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			console.log(data[columnDataName]);
			this.value = data[columnDataName];
		});
	}

	this.GetDataForm = function (formId) {
		var data = {};

		$('#' + formId + ' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			data[columnDataName] = this.value;
		});

		console.log(data);
		return data;
	}

	this.ShowMessage = function (type, message) {
		if (type == 'E') {
			$("#alert_container").removeClass("alert alert-success alert-dismissable")
			$("#alert_container").addClass("alert alert-danger alert-dismissable");
			$("#alert_message").text(message);
		} else if (type == 'I') {
			$("#alert_container").removeClass("alert alert-danger alert-dismissable")
			$("#alert_container").addClass("alert alert-success alert-dismissable");
			$("#alert_message").text(message);
		}
		$('.alert').show();
	};

	this.GetToApi = function (service, callbackFunction) {
		var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
			console.log("Response " + response);
			callbackFunction(response.Data);
		});
	}
	this.PostAPI2 = function (service, data, callbackFunction, callbackFunctionError) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			callbackFunction(response);

		}).fail(function (xhr, status, error) {
			callbackFunctionError(JSON.parse(xhr.responseText).ExceptionMessage);
		})

	};
	this.PostToAPI = function (service, data) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			console.log(response);
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				console.log(response);
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};
}
//Custom jquery actions
$.put = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'PUT',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}
$.delete = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'DELETE',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}