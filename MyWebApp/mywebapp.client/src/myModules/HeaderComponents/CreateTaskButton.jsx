import '../../myStyles/HeaderComponents/CreateTaskButton.css';

function CreateTaskButton(){
    return(
        <div className='CustomButton'>
            <button className='CreateTaskButton'>
                <img src="src/assets/plus.svg" alt="Create" width={15} height={15}/>
            </button>
        </div>
    )
}

export default CreateTaskButton;