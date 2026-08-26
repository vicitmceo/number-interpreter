const input = document.getElementById("numberInput");
const btn = document.getElementById("interpretBtn");
const result = document.getElementById("result");

btn.addEventListener("click", interpret);
input.addEventListener("keydown", (e) => {
    if (e.key === "Enter") interpret();
});

async function interpret() {
    const value = input.value.trim();
    if (value === "") return;

    const response = await fetch("/interpret?number=" + encodeURIComponent(value));
    const data = await response.json();

    if (!response.ok) {
        result.innerHTML = `<span class="error">${data.error}</span>`;
        return;
    }

    result.textContent = data.result;
}
