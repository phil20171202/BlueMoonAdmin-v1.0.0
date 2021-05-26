// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Bar Chart Example
var ctx = document.getElementById("barChartMonthly");
var myLineChart = new Chart(ctx, {

    type: 'bar',
    data: {
        datasets: [{
            label: 'Current Year',
            backgroundColor: "rgba(2,117,216,1)",
            borderColor: "rgba(2,117,216,1)",
            data: [82156, 52312, 66251, 77841, 59821, 14984, 0, 0, 0, 0, 0, 0],
            // this dataset is drawn below
            order: 2
        }, {
            label: 'Previous Year',
            backgroundColor: "rgba(255,255,255)",
            borderColor: "rgba(23,186,239)",
            data: [62156, 42312, 56251, 87841, 49821, 24984, 0, 0, 0, 0, 0, 0],
            type: 'line',
            // this dataset is drawn on top
            order: 1
        }],
        labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]
    },

  options: {
    scales: {
      xAxes: [{
        time: {
          unit: 'month'
        },
        gridLines: {
          display: false
        },
        ticks: {
          maxTicksLimit: 12
        }
      }],
      yAxes: [{
        ticks: {
          min: 0,
          max: 100000,
          maxTicksLimit: 6
        },
        gridLines: {
          display: true
        }
      }],
    },
    legend: {
      display: true
    }
  }
});
