using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem;
using UserControlSystem.UI.Model;
using UserControlSystem.UI.Model.CommandCreator;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectsInstaller", menuName = "RTS/ScriptableObjcetsInstaller")]
public class RTSScriptableObjectInstaller : ScriptableObjectInstaller
{
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private AttackableValue _attackableValue;
    [SerializeField] private AssetsContext _legacyContext;
    
    public override void InstallBindings()
    {
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<AttackableValue>().FromInstance(_attackableValue);
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        
        
    }
}