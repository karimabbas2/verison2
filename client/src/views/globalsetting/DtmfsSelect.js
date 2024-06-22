import React from 'react'
import { useSelector } from 'react-redux'
import { Input } from 'reactstrap'

const DtmfsSelect = (props) => {

    const myStore = useSelector(state => state.RequierdDataStore)
    const Dtmfs = myStore.all_dtmfs
    return (
        <Input type='select' name={props.name} value={props.value} onChange={props.handleOnChange} id='select-basic'>
            {Dtmfs.map((e) => (
                <option key={e.id} value={e.id}>{e.dtmF_Mode}</option>
            ))}
        </Input>
    )
}

export default DtmfsSelect