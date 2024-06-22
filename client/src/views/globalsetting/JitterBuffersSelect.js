import React from 'react'
import { useSelector } from 'react-redux'
import { Input } from 'reactstrap'

const JitterBuffersSelect = (props) => {

    const myStore = useSelector(state => state.RequierdDataStore)
    const jitterBuffers = myStore.all_jitterBuffers

    return (
        <Input type='select' name={props.name} value={props.value} onChange={props.handleOnChange} id='select-basic'>
            {jitterBuffers.map((e) => (
                <option key={e.id} value={e.id}>{e.jitterBuffer_Name}</option>
            ))}
        </Input>
    )
}

export default JitterBuffersSelect