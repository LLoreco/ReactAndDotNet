function ActionButtons(){
    return(
        <div className='ActionButtonsContainer'>
            <button className='ActionButton'>
                <img src="src/assets/pencil.svg" alt="Update" height={20} width={20}/>
            </button>
            <button className='ActionButton'>
                <img src="src/assets/trash.svg" alt="Update" height={20} width={20}/>
            </button>
        </div>
    )
}

export default ActionButtons