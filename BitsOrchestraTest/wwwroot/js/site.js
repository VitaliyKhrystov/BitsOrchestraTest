
if (personData.length != 0) {
    //--------------------------------Filtering--------------------------------------------------------
    var showPeople = function (array) {
        var error = document.getElementById("error");
        var tbody = document.getElementById("tbody");

        if (array.length == 0) {
            tbody.innerHTML = "";
            error.innerHTML = `<span class="error-message">Not Found<\span>`
        }
        else {
            error.innerHTML = "";
            tbody.innerHTML = "";
            for (var i = 0; i < array.length; i++) {
                tbody.innerHTML +=
                    `<tr>
                        <td>${array[i].Name}</td>
                        <td>${array[i].DateofBirth}</td>
                        <td>${array[i].Married}</td>
                        <td>${array[i].Phone}</td>
                        <td>${array[i].Salary}</td>
                        <td>
                            <a class="btn btn-info me-3" href="/Home/Update/${array[i].Id}">Edit</a>
                            <a class="btn btn-danger" href="/Home/Delete/${array[i].Id}">Delete</a>
                        </td>
                    </tr>`
            }
        }

    }

    showPeople(personData);

    var filteredArray = [];


    document.getElementById("search-item").addEventListener("keyup", function () {
    var searchValue = this.value.toString().toLowerCase();
        filteredArray = personData.filter(function (value) {
            if (value.Name.toLowerCase().includes(searchValue) ||
                value.DateofBirth.toLowerCase().includes(searchValue) ||
                value.Married.toString().toLowerCase().includes(searchValue) ||
                value.Phone.toLowerCase().includes(searchValue) ||
                value.Salary.toString().includes(searchValue)) {
                return value;
            }
        }
        )
        showPeople(filteredArray);
        
    });

    //--------------------------------Sorting--------------------------------------------------------

    var elements = document.getElementsByTagName('th');

    if (elements.length != 0) {
        for (var i = 0; i < elements.length; i++) {

            elements[i].addEventListener('click', function () {
                var sortedArray = filteredArray.length != 0 ? filteredArray : personData;
                var column = this.dataset.column;
                var order = this.dataset.order;
                if (order == "desc") {
                    this.dataset.order = "asc";
                    sortedArray = customSort(sortedArray, column, order);
                }
                else {
                    this.dataset.order = "desc";
                    sortedArray = customSort(sortedArray, column, order)
                }
                showPeople(sortedArray);
            })

        }
    }

    var customSort = function (array, column, order) {
        var newArray = array.sort((a, b) => {
            var value1 = a[column];
            var value2 = b[column];

            if (typeof value1 == "string" && typeof value2 == "string") {
                return order == "asc" ? value1.localeCompare(value2) : value2.localeCompare(value1);
            }
            else if (typeof value1 == "number" && typeof value2 == "number") {
                return order == "asc" ? value1 - value2 : value2 - value1;
            }
            else if (typeof value1 == "boolean" && typeof value2 == "boolean") {
                value1 = value1 ? 1 : 0;
                value2 = value2 ? 1 : 0;
                return order == "asc" ? value1 - value2 : value2 - value1;
            }
            else {
                return 0;
            }
        });

        return newArray;
    }


}

   




