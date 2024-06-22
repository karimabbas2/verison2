import React, { useEffect } from 'react'
import { useLocation, useParams } from 'react-router-dom/cjs/react-router-dom.min'
import MyDataTable from './MyDataTable/MyDataTable'
import { useDispatch, useSelector } from 'react-redux'
import { deleteExt, getAllExtenstion } from '../extenison/store'
import withReactContent from 'sweetalert2-react-content'
import Swal from 'sweetalert2'
import { Spinner } from 'reactstrap'
import { getAllTrunks } from '../trunk/store'

function index() {

    const dispatch = useDispatch()
    const { name } = useParams()

    let store = {}

    const handleDelete = async (Id) => {
        console.log(Id)
        const MySwal = withReactContent(Swal)
        return MySwal.fire({
            title: 'Are You Sure Form Deleteing ?!',
            icon: 'warning',
            showCancelButton: true,
            cancelButtonText: 'cancel',
            confirmButtonText: 'Yes !',
            customClass: {
                cancelButton: 'btn btn-danger ml-1',
                confirmButton: 'btn btn-primary'
            },
            buttonsStyling: true
        }).then(function (result) {
            if (result.value) {
                if (name === 'extenison') {
                    dispatch(deleteExt(Id))
                }
            } else if (result.dismiss === MySwal.DismissReason.cancel) {
            }
        })
    }


    useEffect(() => {
        if (name === 'extenison') {
            dispatch(getAllExtenstion(handleDelete))
        } else if (name === 'trunk') {
            dispatch(getAllTrunks)
        }
    }, [name])

    if (name === 'extenison') {
        store = useSelector(state => state.ExtStore)
    } else if (name === 'trunk') {
        store = useSelector(state => state.TrunkStore)
    } else if (name === 'voice-prompts') {
        store = useSelector(state => state.VoicePromptsStore)
    }

    // console.log(store.data)
    console.log(store)
    return (
        <>
            {store.loading ? <div className=' text-center p-lg-4 mt-5 b-transparent center'>
                <Spinner color='danger custom-spinner-loading' />
                <span>Loading Data...</span>
            </div> : <MyDataTable navigate={name} data={store.data} columns={store.columns} />}

        </>

    )
}

export default index