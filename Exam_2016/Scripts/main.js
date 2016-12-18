google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawBasic);

function drawBasic(aData) {

    aData = aData || [['Role','Amount of Employees'],['Loading',24]];

    var data = google.visualization.arrayToDataTable(aData);

    var options = {
        title: 'Employee Role Distribution In The Company'
    };

    var chart = new google.visualization.PieChart(document.getElementById('chart'));

    chart.draw(data, options);
}

function getChartData() {
    $.ajax({
        url: "/Company/GenerateChart",
        type: "POST",
        success: function (data) {
            data = JSON.parse(data);
            handleChartData(data);
        },
        error: function (request, status, error) {
            console.log(error);
        }
    });
}

function handleChartData(data) {

    aData = [['Role', 'Amount of Employees']];

    var rlen = data.Company.Roles.length;
    for (var i = 0; i < rlen; i++) {
        aData.push([data.Company.Roles[i].Name, 0]);
    }

    var elen = data.Employees.length;
    for (var i = 0; i < elen; i++) {
        var ealen = data.Employees[i].AllRoles.length;
        for (var j = 0; j < ealen; j++) {
            var sCurrentRoleName = data.Employees[i].AllRoles[j].Name;

            var alen = aData.length;
            for (var n = 1; n < alen; n++){
                if(aData[n][0] === sCurrentRoleName){
                    aData[n][1]++;
                }
            }
        }
    }

    drawBasic(aData);
}

setTimeout(function () {
    getChartData();
}, 500);

