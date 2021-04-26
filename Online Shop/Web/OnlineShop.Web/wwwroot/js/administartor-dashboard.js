const categories = document.getElementsByClassName("category-name-holder");

for (const category of categories) {
    category.addEventListener('click', loadSubCategories);
}

async function loadSubCategories(e) {
    e.preventDefault();

    if (e.target.dataset.open === "Open") {

        e.target.dataset.open = "Closed";
        e.target.children[0].remove();

    } else if (e.target.parentElement.parentElement.dataset.open === "Open") {

        e.target.parentElement.parentElement.dataset.open = "Closed";
        e.target.parentElement.parentElement.children[0].remove();

    } else {

        e.target.dataset.open = "Open";

        var token = document.querySelector('input[name="__RequestVerificationToken"]').value;

        const categoryId = e.target.dataset.id;
        const url = `/api/CategoriesData/${categoryId}`;

        const subCategories = await (await fetch(url, {
            headers: { 'X-CSRF-TOKEN': token }
        })).json();

        const ulEl = createElement('ul', [], { className: 'list-group list-group-flush' });

        for (const subCategory of subCategories) {
            let liEl = createElement('li', subCategory.name, { className: 'list-group-item' });

            liEl.dataset.id = subCategory.id;

            ulEl.appendChild(liEl);
        }

        e.target.appendChild(ulEl);

    }
}

function createElement(type, content, attributes) {
    const result = document.createElement(type);

    if (attributes !== undefined) {
        Object.assign(result, attributes);
    }

    if (Array.isArray(content)) {
        content.forEach(append);
    } else {
        append(content);
    }

    function append(node) {
        if (typeof node === 'string') {
            node = document.createTextNode(node);
        }

        result.appendChild(node);
    }

    return result;
}
