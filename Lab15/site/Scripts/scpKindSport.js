//var apiBaseUrl = "https://localhost:51570/api/";
var kindSportUrl ="http://localhost:51570/api/kind_sport/";
function reloadKindSportList() {
	var kindSportList = $("#KindSportList");
	if (kindSportList.length) { //Есть элемент для списка пользователей - значит мы на главной странице - можно загрузить список
		$.ajax({
			url: kindSportUrl,
			dataType: "json",
			data: null,
			type: "GET",
			success: function (data) {
				// Do something with the result
				var itemsCount = data.length;
				kindSportList.html("");
				var html = "<table>";
				for (var i = 0; i < itemsCount; i++) {
					var item = data[i];
					var kindSportId = item.id_kind;
					var kindSport_name = item.Name_kind;
					var kindSport_country = item.Group_kind;
					html += "<tr><td>" + kindSportId + "<td><td>" + kindSport_name + "<td><td>" + kindSport_country + "</td>";
					html += "<td><a href='edit.html?id=" + kindSportId + "'>Редактировать</a>&nbsp;<a href='#' class='delete_manufacturer' data-id='" + kindSportId + "'>Удалить</a></td></tr>";
				}
				html += "</table>";
				kindSportList.html(html);
			}
		});
	}
}
$(function () {
	reloadKindSportList();
	var kindSportInfo = $("#KindSportInfo");
	if (kindSportInfo.length) { //Есть элемент для информации о пользователе -  загрузить информацию о нём
		var url_string = window.location.href;
		var url = new URL(url_string);
		var id = url.searchParams.get("id");
		if (id != null) {
			$.ajax({
				url: kindSportUrl + id + "/",
				dataType: "json",
				data: null,
				type: "GET",
				success: function (data) {
					var kindSportId = data.id_kind;
					var kindSport_name = data.Name_kind;
					var kindSport_country = data.Group_kind;
					$("#KindSport_name").val(kindSport_name);
					$("#KindSport_group").val(kindSport_country);
				}
			});
			kindSportInfo.after("<input type='button' id='EditManufacturer' value='Сохранить'/>");
		}
		else {
			kindSportInfo.after("<input type='button' id='CreateManufacturer' value='Создать'/>");
		}
	};
	$(document).on("click", "a.delete_manufacturer", function () {
		var id = $(this).attr("data-id");
		if (id != null) {
			$.ajax({
				url: kindSportUrl + id + "/",
				dataType: "json",
				data: null,
				type: "DELETE",
				success: function (data) {
					reloadKindSportList();
				}
			});
		}
	});
	$(document).on("click", "#CreateManufacturer", function () {
		var kindSportData = {
			Name_kind: $("#KindSport_group").val(),
			Group_kind: $("#KindSport_name").val()
		};
		$.ajax({
			url: kindSportUrl,
			dataType: "json",
			data: kindSportData,
			type: "POST",
			success: function () {
				window.location.href = "../KindSport/index.html";
			}
		});
	});
	$(document).on("click", "#EditManufacturer", function () {
		var url_string = window.location.href;
		var url = new URL(url_string);
		var id = url.searchParams.get("id");
		if (id != null) {
			var kindSportData = {
				id_kind: id,
				Name_kind: $("#KindSport_name").val(),
				Group_kind: $("#KindSport_group").val()
			};
			$.ajax({
				url: kindSportUrl + id + "/",
				dataType: "json",
				data: kindSportData,
				type: "PUT",
				success: function () {
					window.location.href = "../KindSport/index.html";

				}
			});
		}
	});
})