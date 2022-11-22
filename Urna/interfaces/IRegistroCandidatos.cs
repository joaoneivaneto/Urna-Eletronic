using Urna.Models;

namespace Urna.interfaces
{
    public interface IRegistroCandidatos
    {
        List<RegistroCandidatos> List();

        RegistroCandidatos Create(RegistroCandidatos registroCandidatos);

        RegistroCandidatos Update(RegistroCandidatos registroCandidatos);

        RegistroCandidatos GetOne(Guid id);

        RegistroCandidatos Delete (Guid id);
    }
}
