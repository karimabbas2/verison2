// ** React Imports
import { Fragment, useEffect, useState } from 'react'

// ** Dropdowns Imports
import IntlDropdown from './IntlDropdown'
import CartDropdown from './CartDropdown'
import UserDropdown from './UserDropdown'
import NavbarSearch from './NavbarSearch'
import NotificationDropdown from './NotificationDropdown'

// ** Custom Components
import NavbarBookmarks from './NavbarBookmarks'

// ** Third Party Components
import { Sun, Moon } from 'react-feather'
import { NavItem, NavLink } from 'reactstrap'
import ApplaySIPChanges from '../../../../views/sipsetting/SipSetting/ApplaySIPChanges/ApplaySIPChanges'
import { useDispatch, useSelector } from 'react-redux'
import ApplayChangesButton from '../../../../views/ConfigFileApplayChanges/ApplayChanges'

const ThemeNavbar = props => {
  // ** Props
  const { skin, setSkin, setMenuVisibility } = props

  // ** Function to toggle Theme (Light/Dark)
  const ThemeToggler = () => {
    if (skin === 'dark') {
      return <Sun className='ficon' onClick={() => setSkin('light')} />
    } else {
      return <Moon className='ficon' onClick={() => setSkin('dark')} />
    }
  }

  const SipRecord = useSelector(state => state.SIPSettingStore)
  const state = localStorage.getItem("applay_SIP")
  const x = useSelector(state => state.ConfigFileStore)
  // console.log(x)

  return (
    <Fragment>
      <div className='bookmark-wrapper d-flex align-items-center'>
        <NavbarBookmarks setMenuVisibility={setMenuVisibility} />
      </div>
      <ul className='nav navbar-nav align-items-center ml-auto'>
        <div className='mr-1'>
          {x.status ? <ApplayChangesButton /> : null}
        </div>
        <div>
          {state === 'true' ? <ApplaySIPChanges /> : null}
        </div>

        <IntlDropdown />
        <NavItem className='d-none d-lg-block'>
          <NavLink className='nav-link-style'>
            <ThemeToggler />
          </NavLink>
        </NavItem>
        <UserDropdown />
      </ul>
    </Fragment>
  )
}

export default ThemeNavbar
