// Elementos
const inputData = document.getElementById('inputData');
const updateDataBtn = document.getElementById('updateDataBtn');
const chart = d3.select('#chart');
const colors = ['#3498db', '#e74c3c', '#2ecc71', '#f1c40f', '#9b59b6'];


updateDataBtn.addEventListener('click', () => {
    const data = getData();
    if (data.length > 0) {
        updateChart(data);
    }
});

// Funcion para btener datos
const getData = () => {
    const value = inputData.value.trim();
    if (!value) {
        alert('Ingrese datos.');
        return [];
    }
    const data = value.split(',').map(num => parseInt(num.trim()));

    if (data.some(isNaN)) {
        alert('Ingrese numeros separados por coma.');
        return [];
    }

    return data;
}

// Funcion para crear el gráfico
const updateChart = (data) => {

    chart.selectAll('*').remove();

    const width = 500;
    const height = 300;

    // Escalas
    const x = d3.scaleLinear()
        .domain([0, d3.max(data)])
        .range([0, width]);

    const y = d3.scaleBand()
        .domain(data.map((d, i) => i))
        .range([0, height])
        .padding(0.2);

    // SVG
    const svg = chart.append('svg')
        .attr('width', width + 50)
        .attr('height', height);

    // Barras
    svg.selectAll('.bar')
        .data(data)
        .enter()
        .append('rect')
        .attr('class', 'bar')
        .attr('x', 0)
        .attr('y', (d, i) => y(i))
        .attr('width', d => x(d))
        .attr('height', y.bandwidth())
        .attr('fill', (d, i) => colors[i % colors.length])

    svg.selectAll('.label')
        .data(data)
        .enter()
        .append('text')
        .attr('class', 'label')
        .attr('x', d => x(d) - 25) 
        .attr('y', (d, i) => y(i) + y.bandwidth() / 1.5)
        .text(d => d)
        .style('fill', 'white')
        .style('font-size', '16px')
        .style('font-weight', 'bold');

    // Eje X
    svg.append('g')
        .attr('transform', `translate(0, ${height})`)
        .call(d3.axisBottom(x));

    // Eje Y
    svg.append('g')
        .call(d3.axisLeft(y).tickFormat(i => `Item ${i + 1}`));
}


