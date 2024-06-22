import { Check } from "react-feather"
import Avatar from '@components/avatar'

const SuccessToast = (props) => (
    <>
        <div className='toastify-header'>
            <div className='title-wrapper'>
                <Avatar size='sm' color='success' icon={<Check size={12} />} />
                <h6 className='toast-title'>Success!</h6>
            </div>
            <small className='text-muted'>1 Sec Ago</small>
        </div>
        <div className='toastify-body'>
            <span role='img' aria-label='toast-text'>
                {props.msg}

            </span>
        </div>
    </>
)
export default SuccessToast