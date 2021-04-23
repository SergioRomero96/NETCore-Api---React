import api from "./api"

export const ACTION_TYPES = {
    CREATE: 'CREATE',
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    FETCH_ALL: 'FETCH_ALL'
}

const formateData = data => ({
    ...data,
    age: parseInt(data.age ? data.age : 0)
})

export const fetchAll = () => dispatch => {
    api.donationCandidates().fetchAll()
        .then(response => {
            console.log(response);
            dispatch({
                type: ACTION_TYPES.FETCH_ALL,
                payload: response.data
            })
        })
        .catch(error => console.log(error))
}

export const create = (data, onSuccess) => dispatch => {
    data = formateData(data);
    api.donationCandidates().create(data)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.CREATE,
                payload: res.data
            })
            onSuccess()
        })
        .catch(error => console.log(error))
}

export const update = (id, data, onSuccess) => dispatch => {
    data = formateData(data);
    api.donationCandidates().update(id, data)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.UPDATE,
                payload: { id, ...data }
            })
            onSuccess()
        })
        .catch(error => console.log(error))
}

export const deleteDC = (id, onSuccess) => dispatch => {
    api.donationCandidates().delete(id)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.DELETE,
                payload: id
            })
            onSuccess()
        })
        .catch(error => console.log(error))
}