function drawData(data) {
    
    var margin = { top: 20, right: 10, bottom: 20, left: 40 };
    var width = 400 - margin.left -margin.right;
    var height = 200 - margin.top - margin.bottom;

    var svg = d3.select("#plotDiv").append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g").attr("transform", "translate(" + margin.left + " , " + margin.top + ")");

    var xScale = d3.scaleLinear().domain([0, data.length]).range([0, width]);
    var yScale = d3.scaleLinear().domain([0, d3.max(data)]).range([height, 0]); 

    var xAxis = d3.axisBottom().scale(xScale);
    var yAxis = d3.axisLeft().scale(yScale);

    svg.append("g").attr("transform", "translate(0 " + height + ")").call(xAxis);
    svg.append("g").call(yAxis);
    var circles = svg.selectAll("circle").data(data).enter().append("circle").attr('r', 5)
        .attr('cx', function (d, i) { return xScale(i + 1); })
        .attr('cy', function (d, i) { return yScale(d); });
    
}


function avgCalc(data) {
    var avg = 0;

    for (i = 0; i < data.length; i++) {
        avg += data[0];
    }
    avg = avg / data.length;

    return avg;
}