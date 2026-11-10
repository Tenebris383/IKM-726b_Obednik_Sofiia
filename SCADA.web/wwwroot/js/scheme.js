function showReading(r) {
    document.querySelectorAll(`.sensor[data-topic="${r.topic}"]`).forEach(el => {
        el.querySelector('.value').textContent = `${r.value} ${r.unit}`;
        
    });
}

async function refresh()
{
    try 
    {
        const [sensorResponse, alarmResponse] = await Promise.all([
            fetch('/Scheme/Current'),
            fetch('/Scheme/Alarms')
        ]);

        if (!sensorResponse.ok || !alarmResponse.ok) {
            throw new Error(`HTTP ${res.status}`);
        }

        const readings = await sensorResponse.json();
        const alarms = await alarmResponse.json();

        readings.forEach(showReading);

        Object.entries(alarms).forEach(([topic, status]) => {
            showAlarm(topic, status);
        });
    } catch (e) {
        console.error('Update error', e)
    }
}

function showAlarm(topic, status) {
    const elements = document.querySelectorAll(
        `.sensor[data-alarm-topic="${topic}"]`
    );

    elements.forEach(el => {
        el.classList.remove('normal', 'alarm', 'emergency');

        if (status === 'Normal') {
            el.classList.add('normal');
        }
        else if (status === 'Alarm') {
            el.classList.add('alarm');
        }
        else if (status === 'Emergency') {
            el.classList.add('emergency');
        }
    });
}

refresh();
setInterval(refresh, 2000);