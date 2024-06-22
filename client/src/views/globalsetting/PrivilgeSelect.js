import React from 'react'
import { useSelector } from 'react-redux'
import { Input } from 'reactstrap'

const PrivilgeSelect = (props) => {

    const myStore = useSelector(state => state.RequierdDataStore)
    const privileges = myStore.all_privileges

    return (
        <Input type='select' name={props.name} value={props.value} onChange={props.handleOnChange} id='select-basic'>
            {privileges.map((e) => (
                <option key={e.id} value={e.id}>{e.privilege_Name}</option>
            ))}
        </Input>
    )
}

export default PrivilgeSelect