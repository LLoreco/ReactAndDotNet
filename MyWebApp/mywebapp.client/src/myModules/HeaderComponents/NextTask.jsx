import '../../myStyles/HeaderComponents/NextTask.css';

function NextTask({nextTask, timer}){
    return(
        <div className='NextTask'>
            <div className='NextTaskText'>
                {nextTask}
            </div>
            <div className='NextTaskTimer'>
                {timer}
            </div>
        </div>
    )
}
export default NextTask;