//var apiBaseUrl = "https://localhost:44320/api/";
var sportClubUrl ="http://localhost:51570/api/sport_club/";
function reloadSportClubList() {
	var sportClubList = $("#SportClubList");
	if (sportClubList.length) { //Есть элемент для списка пользователей - значит мы на главной странице - можно загрузить список
		$.ajax({
			url: sportClubUrl,
			dataType: "json",
			data: null,
			type: "GET",
			success: function (data) {
				// Do something with the result
				var itemsCount = data.length;
				sportClubList.html("");
				var html = "<table>";
				for (var i = 0; i < itemsCount; i++) {
					var item = data[i];
					var sportClubId = item.id_club;
					var kindSportId = item.id_kind;
					var sportClub_name = item.Name_club;
					var sportClub_text = item.Text_club;
					var sportClub_date = item.CreateDate_club;
					
					html += "<tr><td>" + kindSportId + "</td><td>" + sportClub_name + "</td><td>" + sportClub_text + "</td><td>" + sportClub_date + "</td>";
					html += "<td><a href='edit.html?id=" + sportClubId + "'>Редактировать</a>&nbsp;<a href='#' class='delete_phone' data-id='" + sportClubId + "'>Удалить</a></td></tr>";
				}
				html += "</table>";
				sportClubList.html(html);
			}
		});
	}
}
$(function () {
	reloadSportClubList();
	var sportClubInfo = $("#SportClubInfo");
	if (sportClubInfo.length) { //Есть элемент для информации о пользователе -  загрузить информацию о нём
		var url_string = window.location.href;
		var url = new URL(url_string);
		var id = url.searchParams.get("id");
		if (id != null) {
			$.ajax({
				url: sportClubUrl + id + "/",
				dataType: "json",
				data: null,
				type: "GET",
				success: function (data) {
					var sportClubId = data.id_club;
					var kindSportId = data.id_kind;
					var sportClub_name = data.Name_club;
					var sportClub_text = data.Text_club;
					var sportClub_date = data.CreateDate_club;
					$("#KindSport_id").val(kindSportId);
					$("#SportClub_name").val(sportClub_name);
					$("#SportClub_text").val(sportClub_text);
					$("#SportClub_date").val(sportClub_date);
					
				}
			});
			sportClubInfo.after("<input type='button' id='EditPhone' value='Сохранить'/>");
		}
		else {
			sportClubInfo.after("<input type='button' id='CreatePhone' value='Создать'/>");
		}
	};
	$(document).on("click", "a.delete_phone", function () {
		var id = $(this).attr("data-id");
		if (id != null) {
			$.ajax({
				url: sportClubUrl + id + "/",
				dataType: "json",
				data: null,
				type: "DELETE",
				success: function (data) {
					reloadSportClubList();
				}
			});
		}
	});
	$(document).on("click", "#CreatePhone", function () {
		var phoneData = {
			id_kind: $("#KindSport_id").val(),
			Name_club: $("#SportClub_name").val(),
			Text_club: $("#SportClub_text").val(),
			CreateDate_club: $("#SportClub_date").val()
		};
		$.ajax({
			url: sportClubUrl,
			dataType: "json",
			data: phoneData,
			type: "POST",
			success: function () {
				window.location.href = "../SportClub/index.html";
			}
		});
	});
	$(document).on("click", "#EditPhone", function () {
		var url_string = window.location.href;
		var url = new URL(url_string);
		var id = url.searchParams.get("id");
		if (id != null) {
			var phoneData = {
				id_club: id,
				id_kind: $("#KindSport_id").val(),
				Name_club: $("#SportClub_name").val(),
				Text_club: $("#SportClub_text").val(),
				CreateDate_club: $("#SportClub_date").val()
			};
			$.ajax({
				url: sportClubUrl + id + "/",
				dataType: "json",
				data: phoneData,
				type: "PUT",
				success: function () {
					window.location.href = "../SportClub/index.html";

				}
			});
		}
	});
})