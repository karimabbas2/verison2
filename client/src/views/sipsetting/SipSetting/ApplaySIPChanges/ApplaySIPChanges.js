import React, { useState, useEffect } from 'react'
import { applaySIPChanges, rebootSystem } from '../../store/action'
import { useDispatch } from 'react-redux'
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap'

export default function ApplaySIPChanges() {

    const [basicModal, setBasicModal] = useState(false)

    const handleButtonClick = () => {
        applaySIPChanges()
        setBasicModal(!basicModal)
    }

    const handleReboot = () => {
        rebootSystem()
    }

    // console.log(basicModal)
    return (
        <>
            <Button.Ripple color='primary' onClick={handleButtonClick}>
                Apply SIP Changes
            </Button.Ripple>

            <Modal isOpen={basicModal} toggle={() => setBasicModal(!basicModal)}>
                <ModalHeader toggle={() => setBasicModal(!basicModal)}>FiberMe Alert</ModalHeader>
                <ModalBody>
                    <h5>SIP Setting Alert</h5>
                    To Applay SIP Setting Process, Reboot System !
                </ModalBody>
                <ModalFooter>
                    <Button color='primary' onClick={handleReboot}>
                        Reboot
                    </Button>
                    <Button color='secondary' onClick={() => setBasicModal(false)}>
                        Cancel
                    </Button>
                </ModalFooter>
            </Modal>
        </>
    )
}
