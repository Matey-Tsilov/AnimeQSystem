export default function init() {

    const select = document.querySelector('#country_select2');
    $(select).select2();

    fetch('https://restcountries.com/v3.1/all')
        .then(response => response.json())
        .then(data => {
            data.forEach(country => {
                const option = document.createElement('option');
                option.textContent = country.name.common;
                option.value = country.name.common;
                select.appendChild(option);
            });
        });
}