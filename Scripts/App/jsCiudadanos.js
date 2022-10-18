const uri = 'api/Ciudadanoes';
let todos = [];
//Utilizar el Metodo GET de HTTP
function getCiudadanos() {
    fetch(uri)
        .then(response => response.json())
        .then(data => MostrarCiudadanos(data))
        .catch(error => console.error("No Se Logro Cargar Datos", error));
}
//Insertar Registro de Ciudadanos
function addCiudadano() {
    const addIdentidadTextbox = document.getElementById('Identidad');
    const addNombreTextbox = document.getElementById('Nombre');
    const addApellidoTextbox = document.getElementById('Apellido');
    const addEdadTextbox = document.getElementById('Edad');
    const addResidenciaTextbox = document.getElementById('Residencia');
    const addVacunasTextbox = document.getElementById('Vacunas');
    const addIDVacunaTextbox = document.getElementById('IDVacuna');
    const addFechaUltimaDosisTextbox = document.getElementById('FechaUltimaDosis');

    const item = {
        Identidad: addIdentidadTextbox.value.trimEnd(),
        Nombre: addNombreTextbox.value.trim(),
        Apellido: addApellidoTextbox.value.trim(),
        Edad: addEdadTextbox.value.trim(),
        Residencia: addResidenciaTextbox.value.trim(),
        Vacunas: addVacunasTextbox.value.trim(),
        ID_Vacuna: addIDVacunaTextbox.value.trim(),
        Fecha_Ultima_Dosis: addFechaUltimaDosisTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getCiudadanos();
            addIdentidadTextbox.value = '';
            addNombreTextbox.value = '';
            addApellidoTextbox.value = '';
            addEdadTextbox.value = '';
            addResidenciaTextbox.value = '';
            addVacunasTextbox.value = '';
            addIDVacunaTextbox.value = '';
            addFechaUltimaDosisTextbox.value = '';
        })
        .catch(error => console.error('Error en Agregar Ciudadano.', error));
}
//Eliminar Ciudadano
function deleteCiudadano(Code) {
    fetch(`${uri}/${Code}`, {
        method: 'DELETE'
    })
        .then(() => getCiudadanos())
        .catch(error => console.error('Error en Eliminar Ciudadano.', error));
}
//Mostrar Editor De Datos
function displayEditForm(id) {

    const item = todos.find(item => parseInt(item.Identidad, 10) === id);

    document.getElementById('edit-nombre').value = item.Nombre;
    document.getElementById('edit-identidad').value = item.Identidad;
    document.getElementById('edit-apellido').value = item.Apellido;
    document.getElementById('edit-edad').value = item.Edad;
    document.getElementById('edit-residencia').value = item.Residencia;
    document.getElementById('edit-vacunas').value = item.Vacunas;
    document.getElementById('edit-idvacuna').value = item.ID_Vacuna;
    document.getElementById('edit-fechaultimadosis').value = item.Fecha_Ultima_Dosis;

    document.getElementById('editForm').style.display = 'block';
}
//Actualizar Ciudadano
function updateItem() {
    const identidadCiudadano = document.getElementById('edit-identidad').value;
    const item = {
        Identidad: identidadCiudadano,
        Apellido: document.getElementById('edit-apellido').value.trim(),
        Nombre: document.getElementById('edit-nombre').value.trim(),
        Edad: document.getElementById('edit-edad').value.trim(),
        Residencia: document.getElementById('edit-residencia').value.trim(),
        Vacunas: document.getElementById('edit-vacunas').value.trim(),
        ID_Vacuna: document.getElementById('edit-idvacuna').value.trim(),
        Fecha_Ultima_Dosis: document.getElementById('edit-fechaultimadosis').value.trim()
    };

    fetch(`${uri}/${identidadCiudadano}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getCiudadanos())
        .catch(error => console.error('Error al actualizar Ciudadano.', error));

    closeInput();

    return false;
}
//Cerrar el editor
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}
//Obtener Cantidad de Empleados
function MostrarContador(itemCount) {
    const name = (itemCount === 1) ? 'Registro' : 'Registros';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}
//Metodo Mostrar Empleados
function MostrarCiudadanos(data) {
    const tBody = document.getElementById('DetCiudadanos');
    tBody.innerHTML = '';

    MostrarContador(data.length);

    const button = document.createElement('button');
    data.forEach(item => {

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Editar';
        editButton.setAttribute('onclick', `displayEditForm(${item.Identidad})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Eliminar';
        deleteButton.setAttribute('onclick', `deleteCiudadano(${item.Identidad})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let txtIdentidad = document.createTextNode(item.Identidad);
        td1.appendChild(txtIdentidad);

        let td2 = tr.insertCell(1);
        let txtNombre = document.createTextNode(item.Nombre);
        td2.appendChild(txtNombre);

        let td3 = tr.insertCell(2);
        let txtApellido = document.createTextNode(item.Apellido);
        td3.appendChild(txtApellido);

        let td4 = tr.insertCell(3);
        let txtEdad = document.createTextNode(item.Edad);
        td4.appendChild(txtEdad);

        let td5 = tr.insertCell(4);
        let txtResidencia = document.createTextNode(item.Residencia);
        td5.appendChild(txtResidencia);

        let td6 = tr.insertCell(5);
        let txtVacunas = document.createTextNode(item.Vacunas);
        td6.appendChild(txtVacunas);

        let td7 = tr.insertCell(6);
        let txtIDVacuna = document.createTextNode(item.ID_Vacuna);
        td7.appendChild(txtIDVacuna);

        let td8 = tr.insertCell(7);
        let txtFechaUltimaDosis = document.createTextNode(item.Fecha_Ultima_Dosis);
        td8.appendChild(txtFechaUltimaDosis);

        let td9 = tr.insertCell(8);
        td9.appendChild(editButton);

        let td10 = tr.insertCell(9);
        td10.appendChild(deleteButton);
    });
    todos = data;
}
