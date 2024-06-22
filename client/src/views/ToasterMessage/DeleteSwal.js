import React from 'react'
import withReactContent from 'sweetalert2-react-content'
import Swal from 'sweetalert2'
const MySwal = withReactContent(Swal)

const DeleteSwal = (props) => {
    return (
        MySwal.fire({
            icon: 'success',
            title: 'Deleted!',
            text: props.message,
            customClass: {
                confirmButton: 'btn btn-success'
            }
        })
    )
}

export default DeleteSwal