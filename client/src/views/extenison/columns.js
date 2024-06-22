import { MoreVertical, Edit, Trash } from 'react-feather'
import { Link } from 'react-router-dom/cjs/react-router-dom.min'
import { Badge, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap'


export const Extcolumns = (deleteMethod) => [
  {
    name: 'Extension',
    selector: row => row.ext_Number,
    sortable: true,
    minWidth: '80px'
  },
  {
    name: 'Status',
    selector: 'enable_Ext',
    sortable: true,
    minWidth: '80px',
    cell: row => {
      return (
        <>
          {row.enable_Ext ? <Badge color='light-success'>Enabled</Badge> : <Badge color='light-danger'>Disabled</Badge>}
        </>
      )
    }
  },
  {
    name: 'CallerID Number',
    selector: row => row.callerId_Number,
    sortable: true,
    minWidth: '8px'
  },
  // {
  //   name: 'DTMF Mode',
  //   selector: row => row.dtmF_Mode.dtmF_Mode,
  //   sortable: true,
  //   minWidth: '80px'
  // },
  {
    name: 'First Name',
    selector: row => row.f_Name,
    sortable: true,
    minWidth: '50px'
  },
  {
    name: 'Mobile',
    selector: row => row.mobile,
    sortable: true,
    minWidth: '60px'
  },
  {
    name: 'Actions',
    allowOverflow: true,
    cell: row => {
      return (
        <div className='d-flex'>
          <UncontrolledDropdown>
            <DropdownToggle className='pr-1' tag='span'>
              <MoreVertical size={30} />
            </DropdownToggle>
            <DropdownMenu end>

              <Link to={`/extenison/edit/${row.id}`}>
              <DropdownItem className='w-100'>
                <Edit size={15} className='text-warning' />
                <span className='align-middle ml-50'>Edit</span>
              </DropdownItem>
              </Link>

              <DropdownItem onClick={() => { deleteMethod(row.id) }} className='w-100'>
                <Trash size={15} className=' text-danger' />
                <span className='align-middle ml-50'>Delete</span>
              </DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
        </div>
      )
    }
  }
]