function showReading(r) {
    document.querySelectorAll(`.sensor[data-topic="${r.topic}"]`).forEach(el => {
        el.querySelector('.value').textContent = `${r.value} ${r.unit}`;
        const min = Number(el.dataset.min);
        const max = Number(el.dataset.max);
        const value = Number(r.value);

        const range = max - min;
        const warning = range * 0.1;

        const isEmergency = value < min || value > max;

        const isAlarm = !isEmergency &&
            (value <= min + warning || value >= max - warning);

        el.classList.toggle('normal', !isAlarm && !isEmergency);
        el.classList.toggle('alarm', isAlarm);
        el.classList.toggle('emergency', isEmergency);
        
    });
}

async function refresh()
{
    try 
    {
        const res = await fetch('/Scheme/Current');

        if (!res.ok) {
            throw new Error(`HTTP ${res.status}`);
        }

        const list = await res.json();

        console.log('Received data', list);

        list.forEach(showReading);
    } catch (e) {
        console.error('Update error', e)
    }
}
refresh();
setInterval(refresh, 2000);