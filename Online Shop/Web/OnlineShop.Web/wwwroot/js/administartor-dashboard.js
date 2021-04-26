const categories = document.getElementsByClassName("category-name-holder");

for (const category of categories) {
    category.addEventListener('click', loadSubCategories);
}

function loadSubCategories(e) {
    e.preventDefault();

    const categoryId = e.target.dataset.id;
    alert(categoryId);
}
