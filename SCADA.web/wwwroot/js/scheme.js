function showReading(r) {
    document.querySelectorAll(`.sensor[data-topic="${r.topics}"]`).forEach(el => {
        el.querySelector('.value').textContent = `${r.value} ${r.unit}`;
        
    });
}

async function refresh()
{
    try 
    {
        const res = await fetch('/Scheme/Current');
        const list = await res.json();
        list.forEach(showReading);
    } catch (e) {
        console.error('Update error', e)
    }
}
refresh();
setInterval(refresh, 2000);