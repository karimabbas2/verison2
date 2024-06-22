import React, { useEffect, useState } from 'react'
import { applayChanges } from './action'
import { Button } from 'reactstrap'
import { useDispatch } from 'react-redux'

export default function ApplayChangesButton() {

    const dispatch = useDispatch()
    const handleButtonClick = () => {
        dispatch(applayChanges())
    }

    return (
        <>
            <Button.Ripple color='primary' onClick={handleButtonClick}>
                Apply Changes
            </Button.Ripple>
        </>
    )
}
