import axios from 'axios'
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
const API = axios.create({ baseURL: process.env.REACT_APP_BACKEND_URL })
import { toast } from 'react-toastify'
import { X } from 'react-feather'
import Avatar from '@components/avatar'

const MySwal = withReactContent(Swal)

API.interceptors.response.use(
    res => res,
    error => {
        if (error.response) {
            if (error.response.status === 500) {
                MySwal.fire({
                    title: 'Server Error !!',
                    text: error.response.data,
                    icon: 'error',
                    confirmButtonText: 'Okay!',
                    customClass: {
                        confirmButton: 'btn btn-error'
                    }
                })
            }
            if (error.response.status === 400) {
                const myerror = error.response.data.errors
                if (Object.keys(myerror).length > 0) {
                    toast.error(
                        <>
                            <div className='toastify-header'>
                                <div className='title-wrapper'>
                                    <Avatar size='sm' color='danger' icon={<X size={12} />} />
                                    <h6 className='toast-title'>Error!</h6>
                                </div>
                                <small className='text-muted'>1 Sec Ago</small>
                            </div>
                            <div className='toastify-body'>
                                <span role='img' aria-label='toast-text'>
                                    {Object.keys(myerror).map((key) => (
                                        myerror[key].map((error, index) => (
                                            <li key={`${key}-${index}`}>{error}</li>
                                        ))
                                    ))}
                                </span>
                            </div>
                        </>, { hideProgressBar: true })
                }
            }

        } else {
            // Handle other types of errors, like network errors
            console.error('Network error occurred:', error.message)
        }
        return Promise.reject(error)
    }
)


//Global Defalut setting
export const RequierdData = () => API.get('/GlobalSetting')
export const Record = () => API.get('/GlobalSetting/index')
export const UpdateRecord = (data) => API.post('/GlobalSetting', data)

//Sip Setting
export const GetSipSetting = () => API.get('/SipSetting')
export const UpdateSipSetting = (data) => API.post('/SipSetting', data)
export const ApplaySIPChanges = () => API.get('/SipSetting/ApplaySIPChanges')
export const RebootSystem = () => API.get('/SipSetting/RebootSystem')

//Extenions
export const GetAllExt = () => API.get('/Extension')
export const CreateExt = (data) => API.post('/Extension', data)
export const DeleteExt = (id) => API.delete(`/Extension/${id}`)
export const GetExt = (id) => API.get(`/Extension/${id}`)
export const UpdateExt = (id, data) => API.put(`/Extension/${id}`, data)

//ConfigFileApplayChanges
export const ApplayChanges = () => API.get('/ConfigFile')

//Trunks
export const GetAllTrunks = () => API.get('/Trunk')
export const CreateTrunk = (data) => API.post('/Trunk', data)
export const DeleteTrunk = (id) => API.delete(`/Trunk/${id}`)
export const GetTrunk = (id) => API.get(`/Trunk/${id}`)
export const UpdateTrunk = (data) => API.put('/Trunk', data)
