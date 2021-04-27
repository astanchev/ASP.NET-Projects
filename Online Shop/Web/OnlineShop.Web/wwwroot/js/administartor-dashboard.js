const categories = document.getElementsByClassName("category-name");
//const btnAddCategory = document.getElementsByClassName("btn-add-section")[0];

for (const category of categories) {
    category.addEventListener('click', loadSubCategories);
}

async function loadSubCategories(e) {
    e.preventDefault();
    e.stopPropagation();

    console.log(e.target);

    if (!e.target.classList.contains("category-name")) {
        return;
    }

    if (e.target.dataset.open === "Open") {

        e.target.dataset.open = "Closed";

        while (e.target.childNodes.length > 1) {
            e.target.removeChild(e.target.lastChild);
        }

    } else {

        e.target.dataset.open = "Open";

        var token = document.querySelector('input[name="__RequestVerificationToken"]').value;

        const categoryId = e.target.dataset.id;
        const url = `/api/CategoriesData/${categoryId}`;

        const subCategories = await (await fetch(url, {
            headers: { 'X-CSRF-TOKEN': token }
        })).json();
       
        for (const subCategory of subCategories) {
            let p = createElement('p', subCategory.name, { className: 'subcategory-name' });

            p.dataset.id = subCategory.id;

             e.target.appendChild(p);
        }
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
