// ** Router Import
import { useDispatch, useSelector } from 'react-redux'
import { toast } from 'react-toastify'
import Router from './router/Router'
import { getRecord, getallRequierdData } from './views/globalsetting/store/action'
import { useEffect } from 'react'
import Avatar from '@components/avatar'
import { X } from 'react-feather'
import { getSipSetting } from './views/sipsetting/store/action'
import { getAllExtenstion } from './views/extenison/store'

const App = () => {
    const dispatch = useDispatch()

    useEffect(() => {

        dispatch(getallRequierdData())
        dispatch(getRecord())
        dispatch(getSipSetting())
        // dispatch(getAllExtenstion())

    }, [])

    return (
        <div className="App">
            <Router />
        </div>
    )
}

export default App
